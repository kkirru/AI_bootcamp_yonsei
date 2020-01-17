package com.education.sample.service.auroraDbLookUp;

import com.amazonaws.services.lambda.runtime.Context;
import com.amazonaws.services.lambda.runtime.RequestHandler;
import com.education.sample.utils.AuroraProcessor;

import java.util.List;
import java.util.Map;

public class AuroraDbLookUp implements RequestHandler<RequestClass, ResponseClass> {
    @Override
    public ResponseClass handleRequest(RequestClass requestClass, Context context) {
        AuroraProcessor processor = new AuroraProcessor(requestClass.getSchema());
        int id = 0;
        id = (int) (Math.random() * 100) % 100;
        String query = "SELECT * FROM sample WHERE id = " + id;
        List<Map<String, String>> results = processor.execute(query);
        return new ResponseClass(results);
    }
}
