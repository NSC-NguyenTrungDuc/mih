
package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class ORDERTRANSangTransHandlerTest extends MessageRequestTest{

    @Test
    public void testORDERTRANSangTransInfoRequest() throws Exception {
        NuroServiceProto.ORDERTRANSangTransRequest request = NuroServiceProto.ORDERTRANSangTransRequest.newBuilder()
        		.setHospCode("K01")
        		.setFkout1003("1")
        		.build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}

