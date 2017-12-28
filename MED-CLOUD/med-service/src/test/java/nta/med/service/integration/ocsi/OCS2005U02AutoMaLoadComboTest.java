package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02AutoMaLoadComboTest extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02AutoMaLoadComboRequest request = OcsiServiceProto.OCS2005U02AutoMaLoadComboRequest.newBuilder()
				.setCode("2026")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
