using AutoMapper;
using EFCore.BulkExtensions;
using System.Text;
using TransferLatinToGeorgian.Data.Source;
using TransferLatinToGeorgian.Data.Source.Entities;

public class Program
{
    public async static Task Main()
    {
        var db = new SourceDbContext();
        var list = db.reestris.ToList();

        foreach (var record in list)
        {
            record.gvari = TransferString(record.gvari);
            record.saxeli = TransferString(record.saxeli);
            record.mamisSaxeli = TransferString(record.mamisSaxeli);
            record.quCa = TransferString(record.quCa);
            record.REGMDAT = TransferString(record.REGMDAT);
        }

        var mapper = InitializeAutomapper();
        db.ChangeTracker.AutoDetectChangesEnabled = false;
        var entities = mapper.Map<IEnumerable<reestriGeo>>(list.Where(o => o.piradi is not null).DistinctBy(o => o.piradi)).ToList();
        int batchSize = 10_000;
        for (int i = 0; i < entities.Count(); i += batchSize)
        {
            var nextInsert = entities.Skip(i).Take(Math.Min(batchSize, entities.Count() - batchSize));
            Console.WriteLine($"Inserting {nextInsert.Count()} records.");
            db.BulkInsert(nextInsert, options =>
            {
                options.BatchSize = nextInsert.Count(); // Number of records to insert per batch
            });
            Console.WriteLine($"Inserted {nextInsert.Count()} records and remained {entities.Count() - i} records to insert.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        Console.WriteLine("||||||||||||||||||||||||||||||||||||||||| Saving Changes |||||||||||||||||||||||||||||||||||||||||");

        await db.SaveChangesAsync();

        Console.WriteLine("Done");

        Console.ReadKey();
    }

    private static IMapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<reestri, reestriGeo>().ReverseMap();
        });

        // Create the mapper instance
        var mapper = config.CreateMapper();
        return mapper;
    }

    private static string TransferString(string s)
    {
        if (s is null)
        {
            return null;
        }

        StringBuilder newS = new();
        foreach (var c in s)
        {
            var newC = Transferletter(c);
            newS.Append(newC);
        }

        return newS.ToString();
    }

    private static char Transferletter(char c)
    {
        return c switch
        {
            'a' => 'ა',
            'b' => 'ბ',
            'c' => 'ც',
            'd' => 'დ',
            'e' => 'ე',
            'f' => 'ფ',
            'g' => 'გ',
            'h' => 'ჰ',
            'i' => 'ი',
            'j' => 'ჯ',
            'k' => 'კ',
            'l' => 'ლ',
            'm' => 'მ',
            'n' => 'ნ',
            'o' => 'ო',
            'p' => 'პ',
            'q' => 'ქ',
            'r' => 'რ',
            's' => 'ს',
            't' => 'ტ',
            'u' => 'უ',
            'v' => 'ვ',
            'w' => 'წ',
            'x' => 'ხ',
            'y' => 'ყ',
            'z' => 'ზ',
            'Z' => 'ძ',
            'W' => 'ჭ',
            'T' => 'თ',
            'S' => 'შ',
            'J' => 'ჟ',
            'C' => 'ჩ',
            'R' => 'ღ',
            _ => c
        };
    }
}