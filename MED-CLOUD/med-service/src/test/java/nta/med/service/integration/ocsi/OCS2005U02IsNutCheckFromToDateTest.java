package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02IsNutCheckFromToDateTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02IsNutCheckFromToDateRequest request = OcsiServiceProto.OCS2005U02IsNutCheckFromToDateRequest.newBuilder()
				.setDate("2016/11/11")
				.setBunho("000030556")
				.setBldGubun("1")
				.setPkocs2005("232")
				.setMpressedJaewonYn("Y")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
