package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.*;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.support.supplier.PhrSupplier;

import javax.ws.rs.container.AsyncResponse;
import java.util.concurrent.Callable;
import java.util.concurrent.Executors;
/**
 * @author DEV-TiepNM
 */
public abstract class BaseResource {

    private ListeningExecutorService service = MoreExecutors.listeningDecorator(Executors.newFixedThreadPool(10));
    public <T> ListenableFuture<T> asyncExecute(final PhrSupplier<T> supplier) {
        ListenableFuture<T> future =
                service.submit(new Callable<T>() {
                    public T call() throws Exception {
                        return supplier.get();
                    }
                });
        return (future);
    }
    public <T> void callBackAndResponse(ListenableFuture<T> future, AsyncResponse response)
    {
        Futures.addCallback(future, new FutureCallback<T>() {
            public void onSuccess(T model) {
                response.resume(new MessageResponse.MessageResponseBuilder<T>(Message.MESSAGE_SUCCESS.getValue(),
						Message.SUCCESS.getValue()).setContent(model).build());
            }
            public void onFailure(Throwable thrown) {
                fail(response, thrown);
            }
        });
    }
    public void fail( AsyncResponse response, Throwable thrown)
    {
//        response.resume(new MessageResponse.MessageResponseBuilder<String>(thrown.getMessage() == null ? thrown.getCause().getMessage() : thrown.getMessage(),
//				Message.FAIL.getValue()).build());
    
    	  response.resume(new MessageResponse.MessageResponseBuilder<String>(Message.MESSAGE_REQUEST_INPUT_FAIL.getValue(),
 				Message.FAIL.getValue()).build());
    }
}
