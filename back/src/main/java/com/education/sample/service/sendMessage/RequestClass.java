package com.education.sample.service.sendMessage;

public class RequestClass {

    public String userName;
    public int fieldA;
    public String fieldB;

    public RequestClass() {}

    public RequestClass(String userName, int fieldA, String fieldB) {
        this.userName = userName;
        this.fieldA = fieldA;
        this.fieldB = fieldB;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }
}
