package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01ChangeGubunLayGubunTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01ChangeGubunLayGubunRequest request = InpsServiceProto.INP1001U01ChangeGubunLayGubunRequest.newBuilder()
				.setBunho("000000037")
				.setNaewonDate("2016/10/11")
				.setGubun("T")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
