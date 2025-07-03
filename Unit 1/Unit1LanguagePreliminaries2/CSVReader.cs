using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Formats.Asn1;

namespace CsvFileExample
{
    // Employee class
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    // Class for CSV operations
    public static class CsvOperations
    {
        // Write list to CSV
        public static void WriteToCsv(string filePath, List<Employees> employees)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(employees); // Automatically maps properties to CSV columns
        }

        // Read CSV into list
        public static List<Employees> ReadFromCsv(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<Employees>().ToList(); // Automatically maps CSV columns to properties
        }
    }
}
