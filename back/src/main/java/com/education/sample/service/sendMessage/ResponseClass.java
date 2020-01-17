package com.education.sample.service.sendMessage;

public class ResponseClass {

    public reqData output;

    public Integer exitCode;

    public String message;

    public ResponseClass() {}

    // public ResponseClass(reqData output, Integer exitCode, String message) {
    //     this.output = output;
    //     this.exitCode = exitCode;s
    //     this.message = message;
    // }

    public ResponseClass(RequestClass requestClass,Integer exitCode, String message){
        this.output = new reqData(requestClass.userName, requestClass.fieldA, requestClass.fieldB);
        this.exitCode = exitCode;
        this.message = message;
    }

    public reqData getOutput() {
        return output;
    }

    public void setOutput(reqData output) {
        this.output = output;
    }

    public Integer getExitCode() {
        return exitCode;
    }

    public void setExitCode(Integer exitCode) {
        this.exitCode = exitCode;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}

