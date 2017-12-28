package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ComboListByCodeTypeTest extends MessageRequestTest {

	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

		NuroServiceProto.ComboListByCodeTypeRequest request = NuroServiceProto.ComboListByCodeTypeRequest.newBuilder()
				.setCodeType("SEX_GUBUN")
				.setIsAll(true)
				.build();
		
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
