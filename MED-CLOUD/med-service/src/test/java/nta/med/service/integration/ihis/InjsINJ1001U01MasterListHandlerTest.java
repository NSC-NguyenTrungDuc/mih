package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class InjsINJ1001U01MasterListHandlerTest extends MessageRequestTest{
	
	
	@Test
    public void testInjsINJ1001U01MasterListRequest() throws Exception {
		 InjsServiceProto.InjsINJ1001U01MasterListRequest request = InjsServiceProto.InjsINJ1001U01MasterListRequest.newBuilder()
	                .setActingFlag("N")
	                //.setReserDate("2013/08/08")
	                .setGwa("IR")
	                .build();

        sentRequestToMedApp(request, InjsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
