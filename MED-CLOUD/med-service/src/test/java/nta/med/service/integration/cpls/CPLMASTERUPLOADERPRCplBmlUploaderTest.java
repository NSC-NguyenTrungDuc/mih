package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPLMASTERUPLOADERPRCplBmlUploaderTest  extends MessageRequestTest{
	@Test
	public void cPLMASTERUPLOADERPRCplBmlUploaderTest() throws InterruptedException {
		CplsServiceProto.CPLMASTERUPLOADERPRCplBmlUploaderRequest request = CplsServiceProto.CPLMASTERUPLOADERPRCplBmlUploaderRequest
				.newBuilder()
				.build();
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
