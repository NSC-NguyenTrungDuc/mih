package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q11layQueryTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003Q11layQueryRequest request = OcsiServiceProto.OCS2003Q11layQueryRequest.newBuilder()
				.setHoDong("T")
				.setQueryDate("2016/07/05")
				.setA("N")
				.setB("N")
				.setC("N")
				.setD("N")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
