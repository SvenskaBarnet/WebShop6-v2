namespace WebShop6_v2;

public class Files
{
    public static void Setup()
    {
        if (!File.Exists("inventory.csv"))
        {
            CreateInventory();
        }
        if (!File.Exists("users.csv"))
        {
            File.AppendAllText("users.csv", $"Admin,Password123,Admin{Environment.NewLine}"); //User(Username,Password,Role)    
        }
        Directory.CreateDirectory("Orders");
        Directory.CreateDirectory("Carts");

    }

    static void CreateInventory()
    {
            List<string> inventory = new List<string>();
            inventory.Add("Time - Traveling Cat Condo,2500, A space - themed cat condo designed like a time machine.Complete with comfortable sleeping quarters.");
            inventory.Add("Cat-Proofed Time Machine Collar,1250,A special collar that allows cats to time travel safely with built-in GPS tracking.");
            inventory.Add("Temporal Catnip Balls,850,Cat toys filled with 'time-altering' catnip to keep your furry friend entertained.");
            inventory.Add("Steampunk Cat Goggles,4500,Goggles with a steampunk twist to protect your cat's eyes during time jumps.");
            inventory.Add("Quantum Litter Box,975,A futuristic litter box that instantly cleans itself using quantum technology.");
            inventory.Add("Time-Traveling Cat Bed,345,A cozy cat bed with a design that resembles a vintage time-traveling capsule.");
            inventory.Add("Time-Warping Laser Pointer,3250,A laser pointer that creates mesmerizing time-warping patterns to chase.");
            inventory.Add("Time - Traveling Catnip Mouse,175, A plush toy shaped like a mouse.Filled with catnip.Equipped with a miniature time machine.");
            inventory.Add("Retro Futurist Cat Carrier,645,A stylish and comfortable carrier for time-traveling adventuresn");
            inventory.Add("Dimension-Hopping Cat Tree,1200,A multi-level cat tree with platforms and tunnels that resemble portals to different eras.");
            inventory.Add("Chrono-Collar Camera,4500,A collar-mounted camera that captures your cat's time-traveling escapades.");
            inventory.Add("Time-Traveler's Wardrobe,12000,A collection of cat costumes inspired by different historical periodsn");
            inventory.Add("Space-Time Litter Crystals,75,Litter crystals that emit a soft glow and create a time-travel atmosphere in the litter box.");
            inventory.Add("Catnip-Infused Time Treats,125,Gourmet cat treats infused with catnip and shaped like clock gears or time machines.");
            inventory.Add("Time-Traveling Scratching Post,350,A scratching post with a customizable design that changes with each usen");
            inventory.Add("Temporal Hairball Eliminator,750,A high-tech grooming brush that prevents time-traveling cats from forming hairballsn");
            inventory.Add("Time Capsule Cat Carrier,680,A carrier that looks like a time capsule. Providing a comfortable and secure travel experience.");
            inventory.Add("Time Warp Wall Clock,1000,A wall clock that features mesmerizing time-warping patterns to entertain your cat.");
            inventory.Add("Temporal Tunnel Toy,325,An interactive tunnel toy with LED lights and sound effects to simulate time travel adventures.");
            inventory.Add("Quantum Leap Cat Bedding,275,Bedding sets that depict famous moments in history. Making each cat nap a historical event.");
            foreach (string product in inventory)
            {
                File.AppendAllText("inventory.csv", $"{product}{Environment.NewLine}");
            }

    }
}