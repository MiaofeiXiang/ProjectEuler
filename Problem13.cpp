#include<stdlib.h>
#include<math.h>
#include<fstream>
#include<string>
#include<iostream>
using namespace std;

int main()
{
	string ifile;
	char digit = NULL;
	unsigned int grid[101][51];
	unsigned int result[51];
	int icount = 1;
	int jcount = 1;
	int compressnum;
	int tempresult = 0;
	int iresult;
	ifile = "digits.txt";
    ifstream infile(ifile.c_str(),ios::in);
	if (!infile)
	{
		cerr<< "error; unable to open input file: "<< ifile <<endl;
		return -1;
	}

	while(!infile.eof())
	{
		infile.get(digit);
		if(digit>='0'&&digit<='9')
		{
			grid[icount][jcount]  =  digit - '0';
			jcount++;
		}

		if(jcount==51) 
		{
			icount++;
			jcount = 1;
		}
		
	}
      
        infile.close();

	for(iresult = 50; iresult>=1; iresult--)
	{
		for(icount = 1; icount<=100; icount++)
		{
		  tempresult += grid[icount][iresult]; 
		}

		result[iresult] = tempresult;
		tempresult = 0;
	}

	for(iresult = 50; iresult>=2; iresult--)
	{
		   result[iresult-1] += result[iresult]/10;
		   result[iresult] = result[iresult]%10;
	}

	for(iresult = 1; iresult<=50; iresult++)
		cout<<result[iresult];
                cout<<endl;
  

system("pause");
return 0;
	}