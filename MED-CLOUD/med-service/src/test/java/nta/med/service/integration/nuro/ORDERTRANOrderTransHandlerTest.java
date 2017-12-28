package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class ORDERTRANOrderTransHandlerTest extends MessageRequestTest{

    @Test
    public void testORDERTRANOrderTransRequest() throws Exception {
        NuroServiceProto.ORDERTRANOrderTransRequest request = NuroServiceProto.ORDERTRANOrderTransRequest.newBuilder()
        		.setHospCode("K01")
        		.setFkout1003("1")
        		//.setTransGubun("R")
        		.setTransGubun("N")
        		.build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}