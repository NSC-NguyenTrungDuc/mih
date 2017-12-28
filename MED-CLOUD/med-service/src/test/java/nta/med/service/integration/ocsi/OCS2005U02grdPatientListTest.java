package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02grdPatientListTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02grdPatientListRequest request = OcsiServiceProto.OCS2005U02grdPatientListRequest.newBuilder()
			.setOrderDate("2016/07/05")
			.setFInputGubun("H0")
			.setBunho("000001001")
			.setHoDong("T")
			.setHoCode("T06")
			.setJaewonYn("N")
			.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
