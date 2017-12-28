package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010Q12grdDrgHistoryTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010Q12grdDrgHistoryRequest request = DrgsServiceProto.DRG3010Q12grdDrgHistoryRequest.newBuilder()
				.setBunho("000000115")
				.setYyyymm("201607")
				.setPageNumber("1")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
