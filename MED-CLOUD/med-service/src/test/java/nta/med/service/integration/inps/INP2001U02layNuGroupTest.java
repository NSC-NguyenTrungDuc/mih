package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2001U02layNuGroupTest extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException{
		InpsServiceProto.INP2001U02layNuGroupRequest request = InpsServiceProto.INP2001U02layNuGroupRequest.newBuilder()
				.setBunHo("000000001")
				.setIpwonDate("2016/02/27")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
