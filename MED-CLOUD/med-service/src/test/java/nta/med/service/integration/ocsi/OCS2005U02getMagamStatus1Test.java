package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02getMagamStatus1Test extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02getMagamStatus1Request request = OcsiServiceProto.OCS2005U02getMagamStatus1Request.newBuilder()
				.setMagamDate("11/11/2016")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
