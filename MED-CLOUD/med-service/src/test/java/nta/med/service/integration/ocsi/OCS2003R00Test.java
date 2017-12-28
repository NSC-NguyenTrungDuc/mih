package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003R00Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

//		OcsiServiceProto.OCS2003R00layOCS2001Request request = OcsiServiceProto.OCS2003R00layOCS2001Request.newBuilder()
//				.setBunho("000000011")
//				.setFkinp1001("14589")
//				.setGwa("01")
//				.build();
		
//		OcsiServiceProto.OCS2003R00layPatientRequest request = OcsiServiceProto.OCS2003R00layPatientRequest.newBuilder()
//				.setBunho("000003227")
//				.setFkinp1001("14589")
//				.setGwa("01")
//				.build();
		
		OcsiServiceProto.OCS2003R00layOCS2003Request request = OcsiServiceProto.OCS2003R00layOCS2003Request.newBuilder()
				.setBunho("000003227")
				.setFkinp1001("14589")
				.setGwa("01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
