package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02grdOCS2005Test extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		
		OcsiServiceProto.OCS2005U02grdOCS2005Request request = OcsiServiceProto.OCS2005U02grdOCS2005Request.newBuilder()
					.setBldGubun("2")
					.setJaewonYn("N")
					.setFkinp1001("1617196")
					.setBunho("000003227")
					.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
