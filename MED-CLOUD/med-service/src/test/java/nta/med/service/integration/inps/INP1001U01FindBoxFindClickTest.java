package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01FindBoxFindClickTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01FindBoxFindClickRequest request = InpsServiceProto.INP1001U01FindBoxFindClickRequest.newBuilder()
				.setControlName("fbxJisiDoctor")
				.setFind1("")
				.setBuseoYmd("2016/11/13")
				.setGwa("01")
				.setIpwonDate("2016/11/13")
				.setCodeType("")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
