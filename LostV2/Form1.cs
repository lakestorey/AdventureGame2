/// created by : 
/// date       : 
/// description: A basic text adventure game engine

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostV2
{
    public partial class Form1 : Form
    {
        // tracks what part of the game the user is at
        int scene = 0;
        SoundPlayer wilhelmScream = new SoundPlayer(Properties.Resources.Wilhelm_Scream);
        SoundPlayer lozSecret = new SoundPlayer(Properties.Resources.LOZ_Secret);
        SoundPlayer success = new SoundPlayer(Properties.Resources.Ta_Da_SoundBible_com_1884170640);

        // random number generator
        Random randNum = new Random();
        int leftOrRight;

        public Form1()
        {
            InitializeComponent();

            //display initial message and options
            outputLabel.Text = "Welcome to Mage Quest! M controls the red button, B controls" +
            "the blue button and space controls the yellow button; please select continue";
            redLabel.Text = "Continue";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /// check to see what button has been pressed and advance
            /// to the next appropriate scene
            if (e.KeyCode == Keys.M)       //red button press
            {
                //decide where to go
                if (scene == 0)
                {
                    scene = 1;
                }
                else if (scene == 1)
                {
                    scene = 2;
                }
                else if (scene == 2)
                {
                    scene = 7;
                }
                else if (scene == 3)
                {
                    scene = 5;
                }
                else if (scene == 5)
                {
                    scene = 6;
                }
                else if (scene == 6)
                {
                    scene = 7;
                }
                else if (scene == 7)
                {
                    scene = 0;
                } 
                else if (scene == 8)
                {
                    scene = 7;
                }
                else if (scene == 9)
                {
                    scene = 7;
                }
            }
            else if (e.KeyCode == Keys.B)  //blue button press
            {
                //decide where to go
                if (scene == 0)
                {
                    leftOrRight = randNum.Next(1, 5);
                    if (leftOrRight == 1 || leftOrRight == 2)
                    {
                        scene = 3;
                    }
                    else
                    {
                        scene = 2;
                    }
                }
                else if (scene == 2)
                {
                    scene = 7;
                }
                else if (scene == 1)
                {
                    scene = 3;
                }
                else if (scene == 3)
                {
                    scene = 4;
                }
                else if (scene == 5)
                {
                    scene = 8;
                }
                else if (scene == 4)
                {
                    scene = 7;
                }
            }

            else if (e.KeyCode == Keys.Space)
            {
                if (scene == 1)
                {
                    scene = 9;
                }
            }

            /// Display text and game options to screen based on the current scene
            switch (scene)
            {
                case 0:  //start scene 
                    outputLabel.Text = "Welcome to Mage Quest! M controls the red button and B controls" +
                    "the blue button; please select continue";
                    redLabel.Text = "Continue"; 
                    break;
                case 1:
                    outputLabel.Text = "You are a young mage travelling between cities you come " +
                    "to a fork in the road, do you go left, middle or right?";
                    redLabel.Text = "Left";
                    blueLabel.Text = "Right";
                    yellowLabel.Text = "Middle";
                    break;
                case 2:
                    outputLabel.Text = "You get eaten by a bear.  You are dead";
                    redLabel.Text = "continue";
                    wilhelmScream.Play();
                    break;
                case 3:
                    outputLabel.Text = "you come to a wall of thorns." +
                    "do you try to burn it down with a spell or climb over it?";
                    redLabel.Text = "Spell";
                    blueLabel.Text = "Climb";
                    lozSecret.Play();
                    break;
                case 4:
                    outputLabel.Text = "The thorns are poisonous, you die.";
                    redLabel.Text = "Continue";
                    wilhelmScream.Play();
                    break;
                case 5:
                    outputLabel.Text = "You burn the wall down and walk through." +   
                    "When you get to the town you see a jostling crowd in the town center." +   
                    "Do you go towards them or continue on your way?";
                    redLabel.Text = "Go towards crowd";
                    blueLabel.Text = "Continue on your way";
                    lozSecret.Play();
                    break;
                case 6:
                    outputLabel.Text = "The crown burns you alive for being a witch.";
                    redLabel.Text = "Continue";
                    wilhelmScream.Play();
                    break;
                case 7:
                    outputLabel.Text = "Press M to restart";
                    redLabel.Text = "Restart";
                    break;
                case 8:
                    outputLabel.Text = "You make it to your destination.  Congratulations (You have won.)";
                    redLabel.Text = "Continue";
                    success.Play(); 
                    break;
                case 9:
                    outputLabel.Text = "You fall off of a cliff. You are dead.";
                    redLabel.Text = "Continue";
                    wilhelmScream.Play();
                    break;
                default:
                    break; 
            }
        }

    }

}
