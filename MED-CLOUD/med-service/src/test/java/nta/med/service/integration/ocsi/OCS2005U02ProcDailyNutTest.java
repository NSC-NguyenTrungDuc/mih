package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02ProcDailyNutTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02ProcDailyNutRequest request = OcsiServiceProto.OCS2005U02ProcDailyNutRequest.newBuilder()
				.setBunho("000030556")
				.setChargeDate("2016/07/05")
				.setMpressedJaewonYn("T")
				.setWorkGubun("")
				.setUpdId("99999")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
