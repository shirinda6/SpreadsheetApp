using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class SharableSpreadsheet
{
    private SemaphoreSlim concurrentController;
    public List<List<String>> spreadSheet;
    private int concurrentLimit;
    private int concurrentLimitMax;
    private ConcurrentDictionary<string, ReaderWriterLockSlim> cellLocks;
    private ReaderWriterLockSlim actionChangeLock;

    private string cellKey(int row, int col)
    {
        return row.ToString() + "|" + col.ToString();
    }

    public SharableSpreadsheet(int nRows, int nCols)
    {
        if (nRows < 1 || nCols < 1)
            throw new Exception("Minimum Spread Sheet size is 1x1");
        concurrentLimit = 4;
        concurrentLimitMax = 1000;
        actionChangeLock = new ReaderWriterLockSlim();
        concurrentController = new SemaphoreSlim(concurrentLimit, concurrentLimitMax);
        // construct a nRows*nCols spreadsheet
        cellLocks = new ConcurrentDictionary<string, ReaderWriterLockSlim>();
        spreadSheet = new List<List<String>>();
        for (int r = 1; r <= nRows; r++)
        {
            List<String> colStrList = new List<String>();
            for (int c = 1; c <= nCols; c++)
            {
                String placeHolder = "";
                colStrList.Add(placeHolder);
            }
            spreadSheet.Add(colStrList);
        }
    }

    public String getCell(int row, int col) //func 1
    {
        actionChangeLock.EnterReadLock();
        try
        {
            row -= 1;
            col -= 1;
            if (row < 0 || col < 0)
                return null;
            if (row >= spreadSheet.Count || col >= spreadSheet[0].Count)
                return null;
            // return the string at [row,col]
            ReaderWriterLockSlim aCelllock = cellLocks.GetOrAdd(cellKey(row, col), new ReaderWriterLockSlim());
            aCelllock.EnterReadLock();
            try
            {
                return spreadSheet[row][col];
            }
            finally
            {
                aCelllock.ExitReadLock();
                cellLocks.TryRemove(cellKey(row, col), out _);
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
        }
    }

    public bool setCell(int row, int col, String str)  //func 2
    {
        actionChangeLock.EnterReadLock();
        try
        {

            row -= 1;
            col -= 1;
            if (row < 0 || col < 0)
                return false;
            if (row >= spreadSheet.Count || col >= spreadSheet[0].Count)
                return false;
            // set the string at [row,col]
            ReaderWriterLockSlim aCelllock = cellLocks.GetOrAdd(cellKey(row, col), new ReaderWriterLockSlim());
            aCelllock.EnterWriteLock();
            Thread.Sleep(100);
            try
            {
                spreadSheet[row][col] = str;
                return true;
            }
            finally
            {
                aCelllock.ExitWriteLock();
                cellLocks.TryRemove(cellKey(row, col), out _);
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
        }
    }

    public bool searchString(String str, ref int row, ref int col) //func 3
    {
        concurrentController.Wait();
        actionChangeLock.EnterReadLock();
        try
        {
            if (str == null || str == "")
                return false;
            // search the cell with string str, and return true/false accordingly.
            // stores the location in row,col.
            // return the first cell that contains the string (search from first row to the last row)
            for (int r = 0; r < spreadSheet.Count; r++)
            {
                for (int c = 0; c < spreadSheet[0].Count; c++)
                {
                    ReaderWriterLockSlim aCelllock = cellLocks.GetOrAdd(cellKey(r, c), new ReaderWriterLockSlim());
                    aCelllock.EnterReadLock();
                    try
                    {
                        if (spreadSheet[r][c] == str)
                        {
                            row = (r + 1);
                            col = (c + 1);
                            return true;
                        }
                    }
                    finally
                    {
                        aCelllock.ExitReadLock();
                        cellLocks.TryRemove(cellKey(row, col), out _);
                    }
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
            concurrentController.Release();
        }
        return false;
    }

    public bool exchangeRows(int row1, int row2)  //func 4
    {
        actionChangeLock.EnterReadLock();
        try
        {
            row1 -= 1;
            row2 -= 1;
            if (row1 < 0 || row2 < 0)
                return false;
            if (row1 >= spreadSheet.Count || row2 >= spreadSheet.Count)
                return false;
            if (row1 == row2)
                return false;
            // exchange the content of row1 and row2
            for (int c = 0; c < spreadSheet[0].Count; c++)
            {
                ReaderWriterLockSlim aCelllock1 = cellLocks.GetOrAdd(cellKey(row1, c), new ReaderWriterLockSlim());
                ReaderWriterLockSlim aCelllock2 = cellLocks.GetOrAdd(cellKey(row2, c), new ReaderWriterLockSlim());
                aCelllock1.EnterWriteLock();
                aCelllock2.EnterWriteLock();
                Thread.Sleep(100);
                try
                {
                    string buffer = spreadSheet[row1][c];
                    spreadSheet[row1][c] = spreadSheet[row2][c];
                    spreadSheet[row2][c] = buffer;
                }
                finally
                {
                    aCelllock2.ExitWriteLock();
                    aCelllock1.ExitWriteLock();
                    cellLocks.TryRemove(cellKey(row2, c), out _);
                    cellLocks.TryRemove(cellKey(row1, c), out _);
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
        }
        return true;
    }

    public bool exchangeCols(int col1, int col2) //func 5
    {
        actionChangeLock.EnterReadLock();
        try
        {

            col1 -= 1;
            col2 -= 1;
            if (col1 < 0 || col2 < 0)
                return false;
            if (col1 >= spreadSheet[0].Count || col2 >= spreadSheet[0].Count)
                return false;
            if (col1 == col2)
                return false;
            // exchange the content of col1 and col2
            for (int r = 0; r < spreadSheet.Count; r++)
            {
                ReaderWriterLockSlim aCelllock1 = cellLocks.GetOrAdd(cellKey(r, col1), new ReaderWriterLockSlim());
                ReaderWriterLockSlim aCelllock2 = cellLocks.GetOrAdd(cellKey(r, col2), new ReaderWriterLockSlim());
                aCelllock1.EnterWriteLock();
                aCelllock2.EnterWriteLock();
                Thread.Sleep(100);
                try
                {
                    string buffer = spreadSheet[r][col1];
                    spreadSheet[r][col1] = spreadSheet[r][col2];
                    spreadSheet[r][col2] = buffer;
                }
                finally
                {
                    aCelllock2.ExitWriteLock();
                    aCelllock1.ExitWriteLock();
                    cellLocks.TryRemove(cellKey(r, col1), out _);
                    cellLocks.TryRemove(cellKey(r, col2), out _);
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
        }
        return true;
    }

    public bool searchInRow(int row, String str, ref int col) //func 6
    {
        concurrentController.Wait();
        actionChangeLock.EnterReadLock();
        try
        {
            row -= 1;
            if (row < 0)
                return false;
            if (row >= spreadSheet.Count)
                return false;
            // perform search in specific row
            for (int c = 0; c < spreadSheet[0].Count; c++)
            {
                ReaderWriterLockSlim aCelllock = cellLocks.GetOrAdd(cellKey(row, c), new ReaderWriterLockSlim());
                aCelllock.EnterReadLock();
                try
                {
                    if (spreadSheet[row][c] == str)
                    {
                        col = (c + 1);
                        return true;
                    }
                }
                finally
                {
                    aCelllock.ExitReadLock();
                    cellLocks.TryRemove(cellKey(row, c), out _);
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
            concurrentController.Release();
        }
        return false;
    }

    public bool searchInCol(int col, String str, ref int row) //func 7
    {
        concurrentController.Wait();
        actionChangeLock.EnterReadLock();
        try
        {
            col -= 1;
            if (col < 0)
                return false;
            if (col >= spreadSheet[0].Count)
                return false;
            // perform search in specific col
            for (int r = 0; r < spreadSheet.Count; r++)
            {
                ReaderWriterLockSlim aCelllock = cellLocks.GetOrAdd(cellKey(r, col), new ReaderWriterLockSlim());
                aCelllock.EnterReadLock();
                try
                {
                    if (spreadSheet[r][col] == str)
                    {
                        row = (r + 1);
                        return true;
                    }
                }
                finally
                {
                    aCelllock.ExitReadLock();
                    cellLocks.TryRemove(cellKey(r, col), out _);
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
            concurrentController.Release();
        }
        return false;
    }

    public bool searchInRange(int col1, int col2, int row1, int row2, String str, ref int row, ref int col)//func 8
    {
        concurrentController.Wait();
        actionChangeLock.EnterReadLock();
        try
        {
            row1 -= 1;
            row2 -= 1;
            col1 -= 1;
            col2 -= 1;
            if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0)
                return false;
            if (row1 >= spreadSheet.Count || row2 >= spreadSheet.Count || col1 >= spreadSheet[0].Count || col2 >= spreadSheet[0].Count)
                return false;
            // perform search within spesific range: [row1:row2,col1:col2] 
            //includes col1,col2,row1,row2
            for (int r = row1; r < row2; r++)
            {
                for (int c = col1; c < col2; c++)
                {
                    object aCelllock = cellLocks.GetOrAdd(cellKey(r, c), new ReaderWriterLockSlim());
                    lock (aCelllock)
                    {
                        try
                        {
                            if (spreadSheet[r][c] == str)
                            {
                                row = r;
                                col = c;
                                return true;
                            }
                        }
                        finally
                        {
                            cellLocks.TryRemove(cellKey(r, c), out _);
                        }

                    }
                }
            }
        }
        finally
        {
            actionChangeLock.ExitReadLock();
            concurrentController.Release();
        }
        return false;
    }

    public bool addRow(int row1) //func 9
    {
        actionChangeLock.EnterWriteLock();
        try
        {
            if (row1 < 1)
                return false;
            if (row1 > spreadSheet.Count)
                return false;
            //add a row after row1
            List<String> colList = new List<String>();
            for (int c = 1; c <= spreadSheet[0].Count; c++)
            {
                String placeHolder = "";
                colList.Add(placeHolder);
            }
            spreadSheet.Insert(row1, colList);
            return true;
        }
        finally
        {
            actionChangeLock.ExitWriteLock();
        }
    }

    public bool addCol(int col1) //func 10
    {
        actionChangeLock.EnterWriteLock();
        try
        {
            if (col1 < 1)
                return false;
            if (col1 > spreadSheet[0].Count)
                return false;
            //add a column after col1
            for (int r = 0; r < spreadSheet.Count; r++)
            {
                String placeHolder = "";
                spreadSheet[r].Insert(col1, placeHolder);
            }
            return true;
        }
        finally
        {
            actionChangeLock.ExitWriteLock();
        }
    }

    public void getSize(ref int nRows, ref int nCols)//func 11
    {
        actionChangeLock.EnterReadLock();
        nRows = spreadSheet.Count();
        nCols = spreadSheet[0].Count();
        actionChangeLock.ExitReadLock();
    }

    public bool setConcurrentSearchLimit(int nUsers)//func 12
    {
        actionChangeLock.EnterWriteLock();
        try
        {
            if (nUsers < 1)
                return false;
            if (nUsers > concurrentLimitMax)
                return false;
            // this function aims to limit the number of users that can perform the search operations concurrently.
            // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
            // In this case additional search operations will wait for existing search to finish.
            if (concurrentLimit > nUsers)
            {
                while (concurrentLimit > nUsers)
                {
                    concurrentController.Wait();
                    concurrentLimit--;
                }
            }
            if (concurrentLimit < nUsers)
            {
                int changeAmount = (nUsers - concurrentLimit);
                concurrentController.Release(changeAmount);
                concurrentLimit += changeAmount;
            }
        }
        finally
        {
            actionChangeLock.ExitWriteLock();
        }
        return true;
    }

    public bool save(String fileName) //func 13
    {
        actionChangeLock.EnterWriteLock();
        try
        {
            // save the spreadsheet to a file fileName.
            // you can decide the format you save the data. There are several options.
            TextWriter writer = new StreamWriter(fileName);
            {
                string buffer = "";
                for (int r = 0; r < spreadSheet.Count; r++)
                {
                    for (int c = 0; c < spreadSheet[0].Count - 1; c++)
                    {
                        buffer += spreadSheet[r][c] + "|";
                    }
                    buffer += spreadSheet[r][spreadSheet[0].Count - 1];
                    writer.WriteLine(buffer);
                    buffer = "";
                }
            }
            writer.Close();
        }
        finally
        {
            actionChangeLock.ExitWriteLock();
        }
        return true;
    }

    public bool load(String fileName)//func 14
    {
        actionChangeLock.EnterWriteLock();
        try
        {
            // save the spreadsheet to a file fileName.
            // you can decide the format you save the data. There are several options.
            StreamReader reader = new StreamReader(fileName);
            if (reader == null)
                return false;
            {
                string line;
                spreadSheet = new List<List<string>>();
                while (reader.Peek() >= 0)
                {
                    line = reader.ReadLine();
                    List<string> list = new List<string>();
                    list = line.Split("|").ToList();
                    spreadSheet.Add(list);
                }
            }
        }
        finally
        {
            actionChangeLock.ExitWriteLock();
        }
        return true;
    }
}