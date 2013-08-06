#include<stdlib.h>
#include<iostream>
#define GRIDNUM 20

using namespace std;

int main()
{
	int Num[500]={0};
	int i;
	int j;
	int Addnum=0;
	int tempsum;
	Num[0] = 1;
	for(i=2;i<=100;i++)
	   for(j=0;j<=499;j++)
	   {
		    tempsum = Num[j]*i+Addnum;
			if(tempsum>9)
			  {
				    Num[j] = (Num[j]*i+Addnum)%10;
					Addnum = tempsum/10;				    
			   }
			else
				{
					Num[j] = Num[j]*i+Addnum;
					Addnum = 0;
				}

	   }
	   j = 499;
	   while(Num[j]==0)
	   {
		 j--;
	   }
	   for(;j>=0;j--)
		  {
			  cout<<Num[j];
			  tempsum += Num[j];
		  }
	   cout<<endl;
	   cout<<tempsum;
	system("pause");
	return 0;
}
