using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Authentication;

namespace AddressBook
{
    class Program
    {
        public static string filePath = @"C:\Users\rathi\source\repos_two\AddressBook\AddressBook\AddressBook.txt";
        static void Main(string[] args)
        {
            Program p = new Program();
            int ch = 0; string bname, bname_o;
            Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();// To store new address book with name as Key and value as list
            while (ch != 5)
            {
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Add, edit or delete contacts in an exisiting address Book");
                Console.WriteLine("3. Write contacts to a file");
                Console.WriteLine("4. Read contacts from a file");

                ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)//To create new Book
                {
                    Console.WriteLine("Enter the name of the new address book");
                    bname = Console.ReadLine();//Add the name of the new book to be created
                    List<Contact> clist = new List<Contact>();//Create new List for each new Address Book
                    dict.Add(bname, clist);//Add book name as Key and List as value

                }
                if (ch == 2)//To add to existing book
                {
                    Console.WriteLine("Select Book to add, edit or delete contacts");
                    foreach (string Key in dict.Keys)//Display the names of the book
                    {
                        Console.WriteLine(Key);
                    }
                    bname_o = Console.ReadLine();//Enter the name of the book in which you want to add contatct
                    if (dict.ContainsKey(bname_o))
                    {
                        p.addContact(dict[bname_o]);//function call to perform modification in the books

                    }

                }
                if (ch == 3)
                {
                    Console.WriteLine("Writing Contacts to file");
                    if (File.Exists(filePath))
                    {
                        using (StreamWriter stw = File.CreateText(filePath))
                        {
                            foreach (KeyValuePair<String, List<Contact>> kv in dict)
                            {
                                string a = kv.Key;
                                List<Contact> list1 = (List<Contact>)kv.Value;
                                stw.WriteLine("Address Book Name: " + a);
                                foreach (Contact c in list1)
                                {
                                    stw.WriteLine(c);
                                }
                            }
                            Console.WriteLine("Address Book written into the file successfully!!!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("File doesn't exist!!!");
                    }
                }
                if (ch == 4)
                {
                    Console.WriteLine("Reading contacts from a file");
                    if (File.Exists(filePath))
                    {
                        using (StreamReader str = File.OpenText(filePath))
                        {
                            string s = "";
                            while ((s = str.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist!!!");
                    }
                }

            }
        }
        public void addContact(List<Contact> clist) //To add to exisiting book
        {
            int choice_one = 0;
            while (choice_one != 10)//Iterate till the user exits by inputting choice 5
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. Enter the contact");
                Console.WriteLine("2. Display contacts");
                Console.WriteLine("3. Edit the contact");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("5. Enter the city to display contacts living in it");
                Console.WriteLine("6. Display contacts city wise");
                Console.WriteLine("7. Display sorted contacts city wise");
                Console.WriteLine("8. Display sorted contacts state wise");
                Console.WriteLine("9. Display sorted contacts zip wise");
                Console.WriteLine("10. Exit");
                choice_one = Convert.ToInt32(Console.ReadLine());

                switch (choice_one)
                {
                    case 1://TO add new contact
                        string fname, lname, address, city, state, email;
                        long phoneNumber, zip;
                        Console.WriteLine("Enter the contact details");
                        Console.WriteLine("Enter the first name");
                        fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        lname = Console.ReadLine();
                        Console.WriteLine("Enter the address");
                        address = Console.ReadLine();
                        Console.WriteLine("Enter the city");
                        city = Console.ReadLine();
                        Console.WriteLine("Enter the state");
                        state = Console.ReadLine();
                        Console.WriteLine("Enter the zip code");
                        zip = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the phone number");
                        phoneNumber = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the EmailId");
                        email = Console.ReadLine();
                        Contact contact = new Contact(fname, lname, address, city, state, zip, phoneNumber, email);
                        int flags= 0;
                        foreach (Contact ct in clist)
                        {
                            if (ct.Equals(contact))
                            {
                                Console.WriteLine("Entry of this name is already present. Please enter a new Name");
                                flags = 1;
                                break;
                            }
                        }
                        if (flags == 0)
                        {
                           
                            clist.Add(contact);//Add new contact obj to the list passed in the method
                            Console.WriteLine("Contact Added Successfully");
                        }
                        break;

                    case 2: //To display all contacts sorted by person's name
                        var sortedList = clist.OrderBy(si => si.getFname()).ToList();
                        foreach (Contact o in sortedList)
                        {
                            Console.WriteLine(o);
                        }

                        break;//Print the contacts
                        

                    case 3:
                        Console.WriteLine("Enter the name of the contact to edit");//To edit the contact in the list
                        string name = Console.ReadLine();
                        string f_name, l_name, adrs, cty, st, emailId;
                        long phNo, zp;
                        foreach (Contact obj in clist)
                        {
                            if (obj.getFname().Equals(name))
                            {
                                int choice = 0;
                                Console.WriteLine("Enter the choice to change");
                                Console.WriteLine("1. Change First name");
                                Console.WriteLine("2. Change last name");
                                Console.WriteLine("3. Change the address");
                                Console.WriteLine("4. Change the city");
                                Console.WriteLine("5. Change the state");
                                Console.WriteLine("6. Change the zip");
                                Console.WriteLine("7. Change the phone number");
                                Console.WriteLine("8. Change the EmailID");
                                choice = Convert.ToInt32(Console.ReadLine());
                                if (choice == 1)
                                {
                                    Console.WriteLine("Enter the new First name");
                                    f_name = Console.ReadLine();
                                    obj.setFname(f_name);//Set new value to the attributes of the object


                                }
                                if (choice == 2)
                                {
                                    Console.WriteLine("Enter the new Last name");
                                    l_name = Console.ReadLine();
                                    obj.setLname(l_name);

                                }
                                if (choice == 3)
                                {
                                    Console.WriteLine("Enter the address");
                                    adrs = Console.ReadLine();
                                    obj.setAdd(adrs);

                                }
                                if (choice == 4)
                                {
                                    Console.WriteLine("Enter the new City");
                                    cty = Console.ReadLine();
                                    obj.setCity(cty);

                                }
                                if (choice == 5)
                                {
                                    Console.WriteLine("Enter the new State");
                                    st = Console.ReadLine();
                                    obj.setState(st);

                                }
                                if (choice == 6)
                                {
                                    Console.WriteLine("Enter the new Zip code");
                                    zp = Convert.ToInt64(Console.ReadLine());
                                    obj.setZip(zp);

                                }
                                if (choice == 7)
                                {
                                    Console.WriteLine("Enter the new Phone Number");
                                    phNo = Convert.ToInt64(Console.ReadLine());
                                    obj.setPhoneNo(phNo);

                                }
                                if (choice == 8)
                                {
                                    Console.WriteLine("Enter the new EmailId");
                                    emailId = Console.ReadLine();
                                    obj.setEmailId(emailId);

                                }

                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of the contact to be deleted");//To delete a contact in the list
                        string delname = Console.ReadLine();
                        bool flag = false;
                        List<Contact> Li = new List<Contact>();
                        foreach (Contact obj in clist)
                        {
                            if (obj.getFname().Equals(delname))
                            {
                                flag = true;
                                Li.Add(obj);//Add the contact you want to delete in a list

                            }
                        }
                        clist.RemoveAll(i => Li.Contains(i));//Remove the objects from the list created above from the original list
                        Console.WriteLine("deleted");
                        if (flag)
                        {
                            Console.WriteLine("Contacts deleted");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter the city for displaying contacts");//Enter the city whose contacts needs to be displayed
                        string citi;
                        citi = Console.ReadLine();
                        foreach (Contact c in clist)
                        {
                            if (c.getCity().ToLower().Equals(citi.ToLower()))
                            {
                                Console.WriteLine(c.getFname() + " " + c.getLname());
                            }
                        }
                        break;
                    case 6: Console.WriteLine("Displaying contacts city wise");//Display State wise contacts
                            Dictionary<string, int> sT = new Dictionary<string, int>();
                            HashSet<string> states = new HashSet<string>();
                            foreach (Contact p in clist)
                            {
                                states.Add(p.getState());
                            }
                            foreach(string s in states)
                            {
                                List<string> temp = new List<string>();
                                foreach (Contact c in clist)
                                {
                                    if (s.ToLower().Equals(c.getState()))   
                                    {
                                        temp.Add(c.getFname() +" "+c.getLname());
                                    }
                                }
                                int count=temp.Count;
                                sT.Add(s, count);
                            }
                            foreach (KeyValuePair<string, int> kv in sT)
                            {
                                    Console.WriteLine("The number of persons in {0} is {1} ", kv.Key,kv.Value);  
                            }
                            break;

                    case 7: Contact ctr = new Contact();
                            ctr.SortByCity(clist);

                            foreach (Contact c in clist)
                            {
                                Console.WriteLine(c);
                            }
                           break;//Print 
                    case 8: Contact cts = new Contact();
                            cts.SortByState(clist);

                            foreach (Contact c in clist)
                            {
                                Console.WriteLine(c);
                            }
                            break;
                    case 9: Contact ctd = new Contact();
                            ctd.SortByZip(clist);

                            foreach (Contact c in clist)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                  
                    case 10:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
        }
    }
}
