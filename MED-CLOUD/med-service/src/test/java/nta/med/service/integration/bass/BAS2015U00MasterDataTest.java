package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.integration.MessageRequestTest;

public class BAS2015U00MasterDataTest extends MessageRequestTest{

	@Test
	public void testBAS2015U00MasterData() throws Exception{
	
		BassServiceProto.BAS2015U00MasterDataRequest request = BassServiceProto.BAS2015U00MasterDataRequest.newBuilder()
				.setUserId("SAM001")
				.setActionType(CommonModelProto.ActionType.IMPORT)
				.setKinkiType(CommonModelProto.KinkiType.DRUG_CHECKING)
				//.setUploadPath("info_all.zip")
				.build();
		
		sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
