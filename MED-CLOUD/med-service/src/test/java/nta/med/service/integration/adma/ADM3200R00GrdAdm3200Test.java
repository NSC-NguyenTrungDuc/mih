package nta.med.service.integration.adma;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ADM3200R00GrdAdm3200Test extends MessageRequestTest{

	@Test
    public void test() throws InterruptedException {
		
		// make request
		AdmaServiceProto.ADM3200R00grdADM3200Request request = AdmaServiceProto.ADM3200R00grdADM3200Request.newBuilder()
				.setUserGroup("PFE")
				.setHoDong("PFE")
				.setPageNumber("1")
				.setOffset("10")
				.build();
		
		// send request to med-app
		sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
