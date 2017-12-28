package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02AutoMaSetComboTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02AutoMaSetComboRequest request = OcsiServiceProto.OCS2005U02AutoMaSetComboRequest.newBuilder()
				.setSikGubun("2")
				.build();
		
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
