//2220501001 Hatice Reyhan Çalışkan
//220501009 Betül Canol
using System;
using System.Windows.Forms;

namespace tab_deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ADdding each form to tab control
            //CAPTAINS
            CaptainsForm captainsForm = new CaptainsForm();
            tabControl1.TabPages.Add("Captains", "Captains");
            captainsForm.TopLevel = false;
            tabControl1.TabPages["Captains"].Controls.Add(captainsForm);
            captainsForm.Show();

            //CREW
            CrewForm crewForm = new CrewForm();
            tabControl1.TabPages.Add("Crew", "Crew");
            crewForm.TopLevel = false;
            tabControl1.TabPages["Crew"].Controls.Add(crewForm);
            crewForm.Show();

            //SHIPS
            ShipsForm shipsForm = new ShipsForm();
            tabControl1.TabPages.Add("Ships", "Ships");
            shipsForm.TopLevel = false;
            tabControl1.TabPages["Ships"].Controls.Add(shipsForm);
            shipsForm.Show();

            //PORTS
            PortsForm portsForm = new PortsForm();
            tabControl1.TabPages.Add("Ports", "Ports");
            portsForm.TopLevel = false;
            tabControl1.TabPages["Ports"].Controls.Add(portsForm);
            portsForm.Show();

            //VOYAGES
            VoyagesForm voyagesForm = new VoyagesForm();
            tabControl1.TabPages.Add("Voyages", "Voyages");
            voyagesForm.TopLevel = false;
            tabControl1.TabPages["Voyages"].Controls.Add(voyagesForm);
            voyagesForm.Show();
        }
    }
}