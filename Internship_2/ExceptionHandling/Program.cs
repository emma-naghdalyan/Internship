using System;
using System.IO;

namespace ExceptionHandling
{

    internal sealed class SomeType
    {
        private void SomeMethod()
        {
            using (FileStream fs = new FileStream(@"C:\Data.bin", FileMode.Open))
            {
                // Display 100 divided by the first byte in the file. 
                Console.WriteLine(100 / fs.ReadByte());
            }
        }
    }
    internal sealed class PhoneBook
    {
        private String m_pathname; // path name of file containing the address book 

        // Other methods go here. 

        public String GetPhoneNumber(String name)
        {
            String phone = "";
            FileStream fs = null;
            try
            {
                fs = new FileStream(m_pathname, FileMode.Open);
                // Code to read from fs until name is found goes here 
                // phone = /* the phone # found */
            }
            catch (FileNotFoundException e)
            {
                // Throw a different exception containing the name, and 
                // set the originating exception as the inner exception. 
                // throw new NameNotFoundException(name, e);
            }
            catch (IOException e)
            {
                // Throw a different exception containing the name, and 
                // set the originating exception as the inner exception. 
                // throw new NameNotFoundException(name, e);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            return phone;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }

        private void SomeMethod()
        {

            try
            {
                // Put code requiring graceful recovery and/or cleanup operations here... 
            }
            catch (InvalidOperationException)
            {
                // Put code that recovers from an InvalidOperationException here... 
            }
            catch (IOException)
            {
                // Put code that recovers from an IOException here... 
            }
            catch
            {
                // Put code that recovers from any kind of exception other than those above here... 

                // When catching any exception, you usually re-throw the exception. 
                // I explain re-throwing later in this chapter. 
                throw;
            }
            finally
            {
                // Put code that cleans up any operations started within the try block here... 
                // The code in here ALWAYS executes, regardless of whether an exception is thrown. 
            }
            // Code below the finally block executes if no exception is thrown within the try block 
            // or if a catch block catches the exception and doesn't throw or re-throw an exception. 
        }
        private void ReadData(String pathname)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(pathname, FileMode.Open);
                // Process the data in the file... 
            }
            catch (IOException)
            {
                // Put code that recovers from an IOException here... 
            }
            finally
            {
                // Make sure that the file gets closed. 
                if (fs != null) fs.Close();
            }
        }
    }
}
