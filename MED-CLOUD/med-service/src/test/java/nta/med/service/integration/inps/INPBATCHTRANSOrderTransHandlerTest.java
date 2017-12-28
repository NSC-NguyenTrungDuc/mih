package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INPBATCHTRANSOrderTransHandlerTest extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INPBATCHTRANSOrderTransRequest request = InpsServiceProto.INPBATCHTRANSOrderTransRequest.newBuilder()
				.setTransGubun("N")
				.setFkinp3010("3653242")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
