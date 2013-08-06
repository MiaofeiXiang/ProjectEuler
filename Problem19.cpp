#include<stdlib.h>
#include<iostream>

using namespace std;


class Date
{
	public:
	Date(int inityear = 1900, int initmonth = 1, int initmonthday = 1, int initweekday = 1):year(inityear), month(initmonth), monthday	(initmonthday), weekday(initweekday)
	{
		if(year%4 == 0 && year%100 != 0 || year%400 == 0)
        {
			leap = true;
         }
		else
		{
	 		leap = false;
        }
	}

	int GetYear(){ return year;}
	int GetMonth(){ return month;}
	int GetMonthday(){ return monthday;}
	int GetWeekday(){ return weekday;}
	void GetFormatDate(){cout<<monthday<<"/"<<month<<"/"<<year<<" "<<weekday;}

	Date& operator++(int);

	private:
			int year;
			int month;
			int monthday;
			int weekday;
			bool leap;
};


Date& Date::operator++(int)
{
        if(month == 12 && monthday == 31)
        {
	  		year++;
			if(year%4 == 0 && year%100 != 0 || year%400 == 0)
        	{
				leap = true;
         	}
			else
	 		{
	 			leap = false;
			}
          
        }
        switch(month)
		{
			case 4:
			case 6:
			case 9:
			case 11: if(monthday==30) { month += 1; monthday=1; }else monthday++; break;
			case 2: if(leap&&monthday==29||!leap&&monthday==28) { month += 1; monthday=1; } else monthday++; break;
			default:  if(monthday==31){ month = month%12 + 1; monthday=1; }else monthday++;
		}
		switch(weekday)
		{
			case 1: weekday += 1; break;
			case 2: weekday += 1; break;
			case 3: weekday += 1; break;
			case 4: weekday += 1; break;
			case 5: weekday += 1; break;
			case 6: weekday += 1; break;
			case 7: weekday  = 1; break;
		}
	return *this;
}

int main()
{
	Date Target;
	int count=0;
	while(Target.GetYear()<2001)
	{
		if(Target.GetYear()>=1901&&Target.GetWeekday()==7&&Target.GetMonthday()==1)
		{
			Target.GetFormatDate();
			count++;
			cout<<endl;
		}
		Target++;
	}
	cout<<count<<endl;
	system("pause");
	return 0;
}
