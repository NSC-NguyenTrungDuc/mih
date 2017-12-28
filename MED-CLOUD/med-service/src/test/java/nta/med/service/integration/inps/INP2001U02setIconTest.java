package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2001U02setIconTest extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException{
		InpsServiceProto.INP2001U02setIconRequest request = InpsServiceProto.INP2001U02setIconRequest.newBuilder()
				.setBunho("000000001")
				.setPkOut1001("1960.0")
				.setIpwonDate("2016/03/21")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
