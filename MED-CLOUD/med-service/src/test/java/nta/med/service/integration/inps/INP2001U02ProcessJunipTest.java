package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2001U02ProcessJunipTest extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException{
		InpsServiceProto.INP2001U02ProcessJunipRequest request = InpsServiceProto.INP2001U02ProcessJunipRequest.newBuilder()
				.setInput1("T")
				.setInput2("111")
				.setInput3("222")
				.setInput4("10323")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
