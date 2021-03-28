/*
 * Created by SharpDevelop.
 * User: gurdaan.walia
 * Date: 03/25/2021
 * Time: 14:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Input;
using TipCalculator;
using System.Linq;
using System.Windows.Forms;


namespace TipCalculator
{
	/// <summary>
	/// Description of TipCalculatorViewModel.
	/// </summary>
	/// Propert Change Method
	public class TipCalculatorViewModel:INotifyPropertyChanged
	{
		
		public event PropertyChangedEventHandler PropertyChanged;
		
   		protected void OnPropertyChange(string propertyName) {
        if(PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
		
		/// <summary>
		/// Property For Bill Amount
		/// </summary>
		private float _Bill;
		public float Bill
		{
			get
			{ 
				return _Bill;}
			set{
				_Bill=value;
				OnPropertyChange("Bill");
				OnPropertyChange("TipPerPerson");
				OnPropertyChange("TotalPerPerson");
			}
		}
		
		/// <summary>
		///  Property Of Tip
		/// </summary>
		private float _Tip;
		public float Tip
		{
			get{return _Tip;}
			set{_Tip=value;
				OnPropertyChange("Tip");}
		}
		
		/// <summary>
		/// Property Of Number Of People
		/// </summary>
		private int _NumberOfPeople;
		public int NumberOfPeople
		{
			get{return _NumberOfPeople;}
			set{_NumberOfPeople=value;
				OnPropertyChange("NumberOfPeople");
		        OnPropertyChange("TotalPerPerson");	
			}
		}
		
		/// <summary>
		/// Property For Tip Per Person
		/// </summary>
		private float _TipPerPerson;
		public float TipPerPerson
		{
			get{if(Bill>=1 && Tip>=1 && NumberOfPeople>=1)
				{
					_TipPerPerson=(Tip/100*Bill)/NumberOfPeople;
				}
				
				return _TipPerPerson;}
			set{
				_TipPerPerson=value;
				OnPropertyChange("TipPerPerson");}
		}
		
		/// <summary>
		/// Property For Total Per Person
		/// </summary>
		private float _TotalPerPerson;
		public float TotalPerPerson
		{
			get{
				if(Bill>=1 && NumberOfPeople>=1)
				{
					_TotalPerPerson=Bill/NumberOfPeople;
					
				}
				
				return _TotalPerPerson;
			}
			
			set{_TotalPerPerson=value;
				OnPropertyChange("TotalPerPerson");}
		}
		
		/// <summary>
		/// Logic for decreasing tip amount on button click
		/// </summary>
		private ICommand _TipDecrease=null;
		public ICommand TipDecrease
		{
			get{_TipDecrease=new RelayCommand(TipDecreaseFunction);
				return _TipDecrease;}
			set{
				_TipDecrease=value;
			}
		}
		
		/// <summary>
		/// Logic for increasing tip amount on button click
		/// </summary>
		private ICommand _TipIncrease=null;
		public ICommand TipIncrease
		{
			get {
				_TipIncrease=new RelayCommand(TipIncreaseFunction);
				return _TipIncrease;
			}
			set{
				_TipIncrease=value;
			}
		}
		
		/// <summary>
		/// Logic for increasing number of people on button click
		/// </summary>
		private ICommand _NumberOfPeopleIncrease=null;
		public ICommand NumberOfPeopleIncrease
		{
		get {
				_NumberOfPeopleIncrease=new RelayCommand(NumberOfPeopleIncreaseFunction);
				return _NumberOfPeopleIncrease;
			}
			set{
				_NumberOfPeopleIncrease=value;
			}
		}
		
		/// <summary>
		/// Logic for decresing number of people on button click
		/// </summary>
		private ICommand _NumberOfPeopleDecrease=null;
		public ICommand NumberOfPeopleDecrease
		{
		get {
				_NumberOfPeopleDecrease=new RelayCommand(NumberOfPeopleDecreaseFunction);
				return _NumberOfPeopleDecrease;
			}
			set{
				_NumberOfPeopleDecrease=value;
			}
		}
		
		/// <summary>
		/// Method for decreasing tip
		/// </summary>
		public  void TipDecreaseFunction(object Parameter)
		{
			try{
				if(Tip==0)
				{
					
				}else{
				Tip-=1;	
				OnPropertyChange("TipPerPerson");
				}
				
			}catch(Exception e){ MessageBox.Show("Error in Tip"); }
		}
		
		/// <summary>
		/// Method for increasing tip
		/// </summary>
		public  void TipIncreaseFunction(object Parameter)
		{
			try{
				Tip+=1;
				OnPropertyChange("TipPerPerson");
			}catch(Exception e){ MessageBox.Show("Error in Tip");}
			
		}
		
		/// <summary>
		/// Method for increasing number of people
		/// </summary>
		public void NumberOfPeopleIncreaseFunction(object Parameter)
		{
			try{
				NumberOfPeople+=1;
				OnPropertyChange("TipPerPerson");
			}catch(Exception e){ MessageBox.Show("Error in Number Of People");}
		}
		
		/// <summary>
		/// Method for decreasing number of people
		/// </summary>
		public void NumberOfPeopleDecreaseFunction(object Parameter)
		{
			try{
				if(NumberOfPeople==0){}
				else{
					NumberOfPeople-=1;
					OnPropertyChange("TipPerPerson");
				}
				
			}catch(Exception e){MessageBox.Show("Error in Number Of People");}
		}
		
		
	
		
		public TipCalculatorViewModel()
		{

		}
	}
}
