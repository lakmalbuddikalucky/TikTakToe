using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tictacktoe
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			reset();
		}
		
		int[,] pos=new int[3,3];
	    int control,value,a,b,c=1,d=1,difficulty=3,vs=1;
	    char let;
	    String player1="You",player2="Computer";
	    Random random=new Random();
	    bool turn=true;
	    
	    void reset()
	    {
	        for (int i=0;i<3 ;i++ )
	        {
	            for (int j=0;j<3 ;j++ ){pos[i,j]=0;}
	        }

            //clearing the text fields before starting a new game
	        foreach(Control ctrl in this.Controls)
			{
				if (ctrl is Label) 
				{
					ctrl.ResetText();
				}
			}
	        control=0;
	        value=1;
	        let='X';
	        label10.Text = player1+" to Play NOW.";
	    }
	     
	    bool play(int l,int m)
	    {
	        if(pos[l,m]==0)
	        {
	            a=c;b=d;c=l;d=m;
	            Label ctrl=link(l,m);
	            ctrl.Text=let.ToString();
	            pos[l,m]=value;
	            flip();
	            checkwin(l,m,pos[l,m]);
	            return true;
	        }
	        else
	            return false;
	    }
	    
	    Label link(int l,int m)
	    {
	        if(l==0)
	        {
	            if(m==0)
	                    return label1;
	            if(m==1)
	                    return label2;
	            if(m==2)
	                    return label3;
	        }
	        if(l==1)
	        {
	            if(m==0)
	                    return label6;
	            if(m==1)
	                    return label5;
	            if(m==2)
	                    return label4;
	        }
	        if(l==2)
	        {
	            if(m==0)
	                    return label9;
	            if(m==1)
	                    return label8;
	            if(m==2)
	                    return label7;
	        }
	        return null;
	    }

	    void flip()
	    {
	        if(let=='X')
	        {
	            let = 'O';
	            value=4;
	            control++;
	        }
	        else
	        {
	            let = 'X';
	            value=1;
	            control++;
	        }
	    }
	    
	    void checkwin(int l,int m,int n)
	    {
	        if(control==1)
	            if(vs==1)
	                turn=true;
	        if(control>4)
	        {
	            if((pos[l,0]+pos[l,1]+pos[l,2]==n*3)||(pos[0,m]+pos[1,m]+pos[2,m]==n*3))
	            {
	                control=n;
	            }
	            else
	            {
	                if((pos[0,0]+pos[1,1]+pos[2,2]==n*3)||(pos[2,0]+pos[1,1]+pos[0,2]==n*3))
	                {
	                    control=n;
	                }
	                else
	                {
	                    if(control==9)
	                    {
	                            control=0;
	                    }
	                }
	            }
	            if(control==1||control==0)
	            {
	                if(control==1)
	                    declare(player1+" (Playing X) Wins!");
	                if(control==0)
	                    declare("The Game is a Draw!");
	                reset();
	                if(vs==1)
	                if(player1=="Computer")
	                {
	                    turn=false;
	                    computerPlay(value);
	                }
	                else
	                    turn=false;
	               
	            }
	            else
	            if(control==4)
	            {
	                declare(player2+" (Playing O) Wins!");
	                String temp=player1;
	                player1=player2;
	                player2=temp;
	                reset();
	                if(vs==1)
	                if(player1=="Computer")
	                    computerPlay(value);
	                else
	                    turn=false;
	            }
	        }
	    }
	    
	    void declare(string statement)
		{
			if(MessageBox.Show(statement+"\nDo you want to continue?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)
			{
				Application.Exit();
			}
		}
	    
	     void computerPlay(int n)
	    {
	        bool carry=true;
	        if(difficulty==3)
	            carry=winOrStop(a,b,n);
            if ((difficulty == 2 || difficulty == 3) && carry)
	        {
	            if(n==1)
	                carry=winOrStop(c,d,4);
	            else
	                carry=winOrStop(c,d,1);
	        }
	        if(carry)
	                doAny();
	    }
	     
	    bool winOrStop(int l,int m,int n)
	    {
	        if(pos[l,0]+pos[l,1]+pos[l,2]==n*2)
	        {
	            for(int i=0;i<3;i++)
	            {
	                if(play(l,i))
	                    return false;
	            }
	        }
	        else
	            if(pos[0,m]+pos[1,m]+pos[2,m]==n*2)
	            {
	                for(int i=0;i<3;i++)
	                {
	                    if(play(i,m))
	                        return false;
	                }
	            }
	            else
	                if(pos[0,0]+pos[1,1]+pos[2,2]==n*2)
	                {
	                        for(int i=0;i<3;i++)
	                        {
	                                if(play(i,i))
	                                        return false;
	                        }
	                }
	                else
	                    if(pos[2,0]+pos[1,1]+pos[0,2]==n*2)
	                    {
	                            for(int i=0,j=2;i<3;i++,j--)
	                            {
	                                    if(play(i,j))
	                                            return false;
	                            }
	                    }
	
	        return true;
	    }
	
	    void doAny()
	    {
	        int l=2,m=0;
	        switch(control)
	        {
	            case 0: play(0,0);
	                    break;
	            case 1: if(!(play(1,1)))
	                        play(0,0);
	                    break;
	            case 2: if(!(play(2,2)))
	                        play(0,2);
	                    break;
	            case 3: if((pos[0,1]+pos[1,1]+pos[2,1])==value)
	                        play(0,1);
	                    else
	                        if((pos[1,0]+pos[1,1]+pos[1,2])==value)
	                            play(1,0);
	                        else
	                            if(pos[0,1]!=0)
	                                play(0,2);
	                            else
	                                play(2,0);
	
	                    break;
	            default : while(!(play(l,m)))
	                      {
	                        l=random.Next(3);
	                        m=random.Next(3);
	                      }
	                    break;
	        }
	    }    
		
		void Label1Click(object sender, EventArgs e)
		{
			if(play(0,0)&&turn==true)
            computerPlay(value);
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			 if(play(0,1)&&turn==true)
            computerPlay(value);
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			if(play(0,2)&&turn==true)
            computerPlay(value);
		}
		
		void Label6Click(object sender, EventArgs e)
		{
			if(play(1,0)&&turn==true)
            computerPlay(value);
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			 if(play(1,1)&&turn==true)
            computerPlay(value);
		}
		
		void Label4Click(object sender, EventArgs e)
		{
			 if(play(1,2)&&turn==true)
            computerPlay(value);
		}
		
		void Label9Click(object sender, EventArgs e)
		{
			if(play(2,0)&&turn==true)
            computerPlay(value);
		}
		
		void Label8Click(object sender, EventArgs e)
		{
			if(play(2,1)&&turn==true)
            computerPlay(value);
		}
		
		void Label7Click(object sender, EventArgs e)
		{
			if(play(2,2)&&turn==true)
            computerPlay(value);
		}
		
		//selecting to play against the computer
		void VsComputerToolStripMenuItemClick(object sender, EventArgs e)
		{
			player1="You";
	        player2="Computer";
	        reset();
	        vsComputerToolStripMenuItem.Checked=true;
	        vsPlayerToolStripMenuItem.Checked=false;
	        vs=1;
		}
		
        //selecting to play agianst another player on the same laptop :D 
		void VsPlayerToolStripMenuItemClick(object sender, EventArgs e)
		{
			player1="Player 1";
	        player2="Player 2";
	        reset();
	        vsComputerToolStripMenuItem.Checked=false;
	        vsPlayerToolStripMenuItem.Checked=true;
	        vs=2;
	        turn=false;
		}


        //a new game can be created by clicking this
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (vs == 1)
            {
                player1 = "You";
                player2 = "Computer";
            }
            else
            {
                player1 = "Player 1";
                player2 = "Player 2";
            }
            reset();
        }
	}
}
