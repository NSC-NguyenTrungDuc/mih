package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02layVWOCSOCS2005NUTTest extends MessageRequestTest{
	@Test
	public void Test()throws Exception{
		OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTRequest request = OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTRequest.newBuilder()
				.setBunho("000030556")
				.setFkinp1001("1606719")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}