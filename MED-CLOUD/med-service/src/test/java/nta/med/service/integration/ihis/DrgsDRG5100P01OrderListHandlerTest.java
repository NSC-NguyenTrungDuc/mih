package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.vertx.java.core.Vertx;


public class DrgsDRG5100P01OrderListHandlerTest extends MessageRequestTest {

	@Autowired
	protected Vertx vertx;
    
    @Test
    public void testDrgsDRG5100P01OrderListRequest() throws Exception {
        DrgsServiceProto.DrgsDRG5100P01OrderListRequest request = DrgsServiceProto.DrgsDRG5100P01OrderListRequest.newBuilder()
                .setOrderDate("2012/12/29")
                .setDrgBunho("2")
                .setGubun("3")
                .setWonyoiYn("N")
                .setBunho("099990002")
                .build();



        sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
