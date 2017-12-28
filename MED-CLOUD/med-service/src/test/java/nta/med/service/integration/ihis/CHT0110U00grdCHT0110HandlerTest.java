package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CHT0110U00grdCHT0110HandlerTest extends MessageRequestTest{

    @Test
    public void testGetCHT0110U00grdCHT0110Request() throws Exception {
    	ChtsServiceProto.CHT0110U00grdCHT0110Request request = ChtsServiceProto.CHT0110U00grdCHT0110Request.newBuilder()
        		.setSangInx("ａ３")
        		.build();

        sentRequestToMedApp(request, ChtsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
