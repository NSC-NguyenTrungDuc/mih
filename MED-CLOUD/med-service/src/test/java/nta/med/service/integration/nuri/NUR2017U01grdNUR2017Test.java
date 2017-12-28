package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2017U01grdNUR2017Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2017U01grdNUR2017Request request = NuriServiceProto.NUR2017U01grdNUR2017Request.newBuilder()
				.setBunho("000000001")
				.setOrderGubun("")
				.setActResDate("2017/02/15")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
