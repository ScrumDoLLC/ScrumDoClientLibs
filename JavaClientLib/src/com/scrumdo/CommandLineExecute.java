package com.scrumdo;

import com.scrumdo.helpers.cmd.CmdLn;
import com.scrumdo.helpers.cmd.CmdLnListener;
import com.scrumdo.helpers.cmd.CmdLnOption;
import com.scrumdo.helpers.cmd.CmdLnResult;

public class CommandLineExecute {
    private String fileName = null;
    private int delay = 0;
    public void parseCommandLine(String[] args){
        final CmdLn cmdLn = new CmdLn(args).setDescription(" Welcome to ScrumDo Command Line Interface");
        cmdLn.addOption(
            new CmdLnOption("help",'h').setListener(
                new CmdLnListener(){
                    public void found(CmdLnResult result){
                        cmdLn.printHelp();
                        System.exit(0);
                    }
                }
            )
        );
        cmdLn.addOption(
            new CmdLnOption("user",'u').setRequiredArgument().setDescription("User Resource").setListener(
                new CmdLnListener(){
                    public void found(CmdLnResult result){
                        fileName = result.getArgument();
                    }
                }
            )
        );
        cmdLn.addOption(
                new CmdLnOption("authenticate",'a').setRequiredArgument().setDescription("User Resource").setListener(
                    new CmdLnListener(){
                        public void found(CmdLnResult result){
                            fileName = result.getArgument();
                        }
                    }
                )
            );
        cmdLn.addOption(
            new CmdLnOption("project", 'p').setOptionalArgument().setDescription("Project Resource").setListener(
                new CmdLnListener(){
                    public void found(CmdLnResult result){
                        delay = 5000;
                        if (result.getArgumentCount() > 0){
                            delay = Integer.parseInt(result.getArgument()) * 1000;
                        }
                    }
                }
            )
        );
        cmdLn.parse();
    }
}
