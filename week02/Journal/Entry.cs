using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = prompt;
        _response = response;
    }

    public string DisplayEntry()
    {
        return $"{_date} | {_prompt}\n{_response}\n";
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileFormat(string line)
    {
        try
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 3)
            {
                return new Entry(parts[1], parts[2]) { _date = parts[0] };
            }
            else
            {
                Console.WriteLine($"Warning: Invalid entry format in line: {line}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing entry: {ex.Message}");
            return null;
        }
    }
}
