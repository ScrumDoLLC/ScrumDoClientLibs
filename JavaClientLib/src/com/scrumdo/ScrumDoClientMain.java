package com.scrumdo;
/**
 *  ScrumDo - Agile/Scrum story management web application
 *  Copyright (C) 2011 ScrumDo LLC
 *
 * This software is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy (See file COPYING) of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

 */

import java.io.*;

import com.scrumdo.helpers.cmd.CmdLn;
import com.scrumdo.helpers.cmd.CmdLnListener;
import com.scrumdo.helpers.cmd.CmdLnOption;
import com.scrumdo.helpers.cmd.CmdLnResult;
/**
 * @author ajay
 *
 */


public class ScrumDoClientMain {


    public static void main(String[] args) throws Exception {
    	CommandLineExecute optionCallback = new CommandLineExecute();
        optionCallback.parseCommandLine(args);
//        if (optionCallback.delay > 0){
//            Thread.sleep(optionCallback.delay);
//        }
//        if (optionCallback.fileName != null){
//            // open file and do work...
//        }
//        for(String argument: cmd.getNonOptionArguments()){
//            // other arguments
//        }
    }
}
