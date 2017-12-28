package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001R04cboHodongTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001R04cboHodongRequest request = InpsServiceProto.INP1001R04cboHodongRequest.newBuilder()
				
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
