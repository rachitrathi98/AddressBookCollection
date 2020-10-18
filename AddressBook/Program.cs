using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace AddressBook
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            int ch = 0; string bname, bname_o;
            Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();// To store new address book with name as Key and value as list
            while (ch != 3)
            {
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Add, edit or delete contacts in an exisiting address Book");
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

            }
        }
        public void addContact(List<Contact> clist) //To add to exisiting book
        {
            int choice_one = 0;
            while (choice_one != 5)//Iterate till the user exits by inputting choice 5
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. Enter the contact");
                Console.WriteLine("2. Display contacts");
                Console.WriteLine("3. Edit the contact");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("5. Exit");
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
                        clist.Add(contact);//Add new contact obj to the list passed in the method
                        break;

                    case 2: //To display all contacts
                        foreach (Contact o in clist)
                        {
                            Console.WriteLine(o.toString());
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
