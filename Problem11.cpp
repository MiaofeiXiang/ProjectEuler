#include<stdlib.h>
#include<math.h>
#include<fstream>
#include<string>
#include<iostream>
using namespace std;

int upperRight(int i,int j, int grid[][21])
{
 	int Product = 0;
        int ivec = i + 3;
        int jvec = j - 3;
        if(grid[i][j]!=0&&ivec<=20&&jvec>=1)
      {
       Product = grid[i][j]*grid[i+1][j-1]*grid[i+2][j-2]*grid[i+3][j-3];
       return Product;
       }
        else return Product;  
}

int RightHorizon(int i,int j, int grid[][21])
{
        int Product = 0;
        int ivec = i;
        int jvec = j + 3;
        if(grid[i][j]!=0&&jvec<=20)
      {
       Product = grid[i][j]*grid[i][j+1]*grid[i][j+2]*grid[i][j+3];
       return Product;
       }
        else return Product;
 	  
}

int DownRight(int i,int j, int grid[][21])
{
	int Product = 0;
        int ivec = i + 3;
        int jvec = j + 3;
        if(grid[i][j]!=0&&ivec<=20&&jvec<=20)
      {
       Product = grid[i][j]*grid[i+1][j+1]*grid[i+2][j+2]*grid[i+3][j+3];
       return Product;
       }
        else return Product;
 	  
}

int Down(int i,int j, int grid[][21])
{
	int Product = 0;
        int ivec = i + 3;
        int jvec = j;
        if(grid[i][j]!=0&&ivec<=20)
      {
       Product = grid[i][j]*grid[i+1][j]*grid[i+2][j]*grid[i+3][j];
       return Product;
       }
        else return Product;
 	  
}
	
int main()
{
	string ifile;
	char digit = NULL;
	int grid[21][21];
	int icount = 1;
	int jcount = 1;
	int Product = 0;
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
			grid[icount][jcount]  =  (digit - '0')*10;
			infile.get(digit);
			grid[icount][jcount]  +=  digit - '0';
			jcount++;
		}

		if(jcount==21) 
		{
			icount++;
			jcount = 1;
		}
		
	}

	for(icount=1;icount<=20;icount++)
		for(jcount=1; jcount<=20; jcount++)
		{
			int temp;
			temp = upperRight(icount,jcount,grid);
			if(temp>Product) Product = temp;

			temp = RightHorizon(icount,jcount,grid);
			if(temp>Product) Product = temp;

			temp = DownRight(icount,jcount,grid);
			if(temp>Product) Product = temp;

			temp = Down(icount,jcount,grid);
			if(temp>Product) Product = temp;
		}

cout<<Product<<endl;
  

system("pause");
return 0;
	}