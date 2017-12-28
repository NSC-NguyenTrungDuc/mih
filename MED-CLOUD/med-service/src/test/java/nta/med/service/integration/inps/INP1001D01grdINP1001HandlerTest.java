package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001D01grdINP1001HandlerTest extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001D01grdINP1001Request request = InpsServiceProto.INP1001D01grdINP1001Request.newBuilder()
				.setQueryDate("2016/12/14")
				.setHoDong("%")
				.setSuName("")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
