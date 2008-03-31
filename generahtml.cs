/*
 * Copyright (C) 2006 Jordi Mas i Hernàndez <jmas@softcatala.org>
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as
 * published by the Free Software Foundation; either version 2 of the
 * License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public
 * License along with this program; if not, write to the
 * Free Software Foundation, Inc., 59 Temple Place - Suite 330,
 * Boston, MA 02111-1307, USA.
 */

using System.IO;
using System.Text;
using System;

public class Genera
{
		static void Main ()
		{
			string line, s_out;
			string [] entry;
			Stream read = File.OpenRead ("recull.csv");
			Stream header = File.OpenRead ("header.htm");
			Stream tail = File.OpenRead ("tail.htm");
			Stream write = File.OpenWrite ("recull.htm");
			StreamReader sr;
			StreamWriter sw = new StreamWriter (write);
			
			sr = new StreamReader (header);
			sw.Write (sr.ReadToEnd ());

			sr = new StreamReader (read);			
			
			while (true) {
				line = sr.ReadLine ();
				if (line == null)
					break;
					
				entry = line.Split (new char[] {';'});
				
				s_out = "<tr><td>";
				s_out += entry [0];
				s_out += "</td><td>";				
				s_out += entry [1];
				s_out += "</td><td>";
				s_out += entry [2];
				s_out +="</td></tr>";			
				
				sw.WriteLine (s_out);
				
			}

			sr = new StreamReader (tail);
			sw.Write (sr.ReadToEnd ());
			sw.Flush ();
			write.Close ();
		}

}


