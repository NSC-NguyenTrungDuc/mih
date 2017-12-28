package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OUT0101U02ComboListTest extends MessageRequestTest {

	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

		NuroServiceProto.OUT0101U02ComboListRequest request = NuroServiceProto.OUT0101U02ComboListRequest.newBuilder()
				.setBunhoCodeType("BUNHO_TYPE")
				.setSexCodeType("SEX_GUBUN")
				.setTelCodeType("TEL_GUBUN")
				.setBoninCodeType("BON_GA_GUBUN")
				.build();
		
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
