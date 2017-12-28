package nta.med.service.integration.adma;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaModelProto.ADM2016U00GrdLoadDrgInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class HOTCODEMASTERSaveTest extends MessageRequestTest {
	@Test
	public void testHOTCODEMASTERSave() throws InterruptedException {
		ADM2016U00GrdLoadDrgInfo.Builder info = ADM2016U00GrdLoadDrgInfo.newBuilder();
		info.setA1("1108880020201");
		AdmaServiceProto.HOTCODEMASTERSaveRequest request = AdmaServiceProto.HOTCODEMASTERSaveRequest.newBuilder()
				.addHotCodeInfo(info)
				.build();
		sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
