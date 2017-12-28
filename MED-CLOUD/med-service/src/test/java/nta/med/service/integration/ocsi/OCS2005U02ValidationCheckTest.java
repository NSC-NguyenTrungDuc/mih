package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.core.glossary.DataRowState;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02ValidationCheckTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiModelProto.OCS2005U02grdOCS2005Info.Builder item = OcsiModelProto.OCS2005U02grdOCS2005Info.newBuilder();
		item.setBldGubun(("1"));
		item.setBunho("000030556");
		item.setDataRowState(DataRowState.MODIFIED.toString());
		item.setDirectCont1("0322");
		item.setDirectCont1D("035");
		item.setDirectCont2("0323");
		item.setDirectCont2D("049");
		item.setDirectCont3("0324");
		item.setDirectCont3D("026");
		item.setDrtFromDate("2016/07/05");
		item.setDrtToDate("2016/07/05");
		item.setPkocs2005("162017");
		OcsiServiceProto.OCS2005U02ValidationCheckRequest request = OcsiServiceProto.OCS2005U02ValidationCheckRequest.newBuilder()
				.setBunho("000030556")
				.setMpressedJaewonYn("Y")
				.setCboBusik("1")
				.setCboJusik("1")
				.setCboBusik("1")
				.addInfoGrd(0,item)
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
				
	}
}