package com.education.sample.service.sendMessage;

import com.amazonaws.services.lambda.runtime.Context;
import com.amazonaws.services.lambda.runtime.RequestHandler;

public class SendMessage implements RequestHandler<RequestClass, ResponseClass> {
    @Override
    public ResponseClass handleRequest(RequestClass requestClass, Context context) {
        return new ResponseClass(
            requestClass,200,"SUCCESS"
    );
    }
    // @Override
    // public ResponseClass handleRequest(RequestClass requestClass, Context context) {
    //     return new ResponseClass(
    //             String.format("User name : %s\r\nfieldA : %d\r\nfieldB : %s", 
    //             requestClass.getUserName(), requestClass.fieldA, requestClass.fieldB),
    //             200,
    //             "SUCCESS"
    //     );
    // }
}
